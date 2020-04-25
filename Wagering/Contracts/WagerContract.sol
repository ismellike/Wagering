pragma solidity ^0.6.4;


contract ERC20Interface {
    function totalSupply() public pure returns (uint256);

    function balanceOf(address tokenOwner)
        public
        pure
        returns (uint256 balance);

    function allowance(address tokenOwner, address spender)
        public
        pure
        returns (uint256 remaining);

    function transfer(address to, uint256 tokens) public returns (bool success);

    function approve(address spender, uint256 tokens)
        public
        returns (bool success);

    function transferFrom(address from, address to, uint256 tokens)
        public
        returns (bool success);

    event Transfer(address indexed from, address indexed to, uint256 tokens);
    event Approval(
        address indexed tokenOwner,
        address indexed spender,
        uint256 tokens
    );
}


contract WagerContract {
    enum State {Active, Completed, Canceled}
    //percentage 0 - 100
    //teams 0, 1, 2, ... 255
    struct Bid {
        address payable _address;
        uint8 percentage;
        uint8 team;
    }
    address payable owner = msg.sender;
    ERC20Interface usdc = ERC20Interface(
        0xA0b86991c6218b36c1d19D4a2e9Eb0cE3606eB48
    );
    uint8 teamCount = 0;
    uint256 prizePool = 0;
    Bid[][] public bids;

    modifier onlyOwner {
        //wagering.gg is owner
        require(msg.sender == owner, "Only contract owner can call this.");
        _;
    }

    function addTeam(
        address payable[] memory _addresses,
        uint8[] memory _percentages,
        uint256 _amount
    ) public onlyOwner {
        uint256 length = _addresses.length;
        require(length == _percentages.length, "Array lengths must be equal.");
        for (uint256 i = 0; i < length; i++) {
            require(
                _amount < usdc.balanceOf(_addresses[i]),
                "Insufficient balances in a user."
            );
            bids[teamCount].push(
                Bid(_addresses[i], _percentages[i], teamCount)
            );
        }
        teamCount++;
        prizePool += _amount;
    }

    function complete(uint256 _winningTeam) public payable onlyOwner {
        require(
            _winningTeam < teamCount,
            "Winning team must be within total teams count"
        );
        uint256 length = bids[_winningTeam].length;
        //owner.transfer(prizePool * .1); give 10%
        for (uint256 i = 0; i < length; i++) {
            //bids[_winningTeam][i]._address.transfer(); transfer x%
        }
    }

    function cancel() public payable onlyOwner {}
}
