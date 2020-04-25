pragma solidity ^0.6.4;
import "./IERC20.sol";


contract WagerContract {
    enum State {Active, Completed, Canceled}
    struct Bid {
        address payable _address; //160
        uint8 percentage; //168
        uint8 team; //176
    }
    address payable owner = msg.sender;
    IERC20 public constant usdc = IERC20(
        0xA0b86991c6218b36c1d19D4a2e9Eb0cE3606eB48
    );
    uint8 teamCount = 0;
    uint256 prizePool = 0;
    Bid[][] public bids;

    modifier onlyOwner {
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
