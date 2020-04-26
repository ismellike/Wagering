pragma solidity ^0.6.4;
import "./IERC20.sol";
import "./SafeMath.sol";


contract WagerContract {
    using SafeMath for uint256;
    struct Bid {
        uint8 _team; //8
        uint8 _receivable; //16
        uint64 _paid; //80
        address payable _address; //240
    }
    struct State {
        uint8 _payable; //8
        uint8 _receivable; //16
        uint8 _totalPayable; //24
        uint8 _totalReceivable; //32
        uint8 _length; //40
        uint56 _bidAmount; //96
        address payable _address; //256
    }
    address payable owner = msg.sender;
    IERC20 public constant usdc = IERC20(
        0xA0b86991c6218b36c1d19D4a2e9Eb0cE3606eB48
    );
    uint256 teamCount = 0;
    uint256 prizePool = 0;
    bool closed = false;
    mapping(uint256 => Bid[]) public bids;

    modifier onlyOwner {
        require(msg.sender == owner, "Only contract owner can call this.");
        _;
    }

    modifier notClosed {
        require(closed == false, "Contract is already closed.");
        _;
    }

    ///Add a team to the bids.
    function addTeam(
        address payable[] memory _addresses,
        uint256[] memory _payables,
        uint256[] memory _receivables,
        uint256 _amount
    ) public onlyOwner notClosed {
        require(_amount > 0, "Amount must be greater than zero.");
        State memory state;
        state._length = uint8(_addresses.length);
        require(
            state._length == _payables.length,
            "Array lengths must be equal."
        );
        require(
            state._length == _receivables.length,
            "Array lengths must be equal."
        );
        for (uint256 i = 0; i < state._length; i++) {
            state._receivable = uint8(_receivables[i]);
            require(
                state._receivable <= 100,
                "Single percentage cannot be greater than 100."
            );
            state._totalReceivable += state._receivable;
            require(
                state._totalReceivable <= 100,
                "Total percentage cannot be greater than 100."
            );
            state._payable = uint8(_payables[i]);
            require(
                state._payable <= 100,
                "Single percentage cannot be greater than 100."
            );
            state._totalPayable += state._payable;
            require(
                state._totalPayable <= 100,
                "Total percentage cannot be greater than 100."
            );
            state._bidAmount = uint56(
                SafeMath.div(SafeMath.mul(_amount, state._payable), 100)
            );
            state._address = _addresses[i];
            require(
                usdc.balanceOf(state._address) >= state._bidAmount,
                "Insufficient balances of a user."
            );
            require(
                usdc.transferFrom(
                    state._address,
                    address(this),
                    state._bidAmount
                ),
                "Transaction could not be completed."
            );
            //allow state._address bidAmount
            bids[teamCount].push(
                Bid(
                    uint8(teamCount),
                    state._receivable,
                    state._bidAmount,
                    state._address
                )
            );
        }
        require(
            state._totalPayable == 100,
            "Total percentage must be equal to 100."
        );
        teamCount++;
        prizePool += _amount;
    }

    ///Complete the wager with a winning team.
    function complete(uint256 _winningTeam, bool _verified)
        public
        payable
        onlyOwner
        notClosed
    {
        require(
            _winningTeam < teamCount,
            "Winning team must be within team count."
        );
        uint256 length = bids[_winningTeam].length;
        uint256 pool = SafeMath.div(
            SafeMath.mul(prizePool, (_verified ? 93 : 90)),
            100
        );
        for (uint256 i = 0; i < length; i++) {
            uint256 poolPortion = SafeMath.div(
                SafeMath.mul(pool, bids[_winningTeam][i]._receivable),
                100
            );
            require(
                usdc.transferFrom(
                    address(this),
                    bids[_winningTeam][i]._address,
                    poolPortion
                ),
                "Transaction could not be completed."
            );
        }
        require(
            usdc.transferFrom(
                address(this),
                owner,
                usdc.balanceOf(address(this))
            ),
            "Transaction could not be completed."
        );
        closed = true;
    }

    ///Return all funds to users.
    function cancel() public payable onlyOwner notClosed {
        for (uint256 i = 0; i < teamCount; i++) {
            uint256 length = bids[i].length;
            for (uint256 j = 0; j < length; j++) {
                uint256 amount = SafeMath.div(
                    SafeMath.mul(bids[i][j]._paid, 95),
                    100
                );
                require(
                    usdc.transferFrom(
                        address(this),
                        bids[i][j]._address,
                        amount
                    ),
                    "Transaction could not be completed."
                );
            }
        }
        require(
            usdc.transferFrom(
                address(this),
                owner,
                usdc.balanceOf(address(this))
            ),
            "Transaction could not be completed."
        );
        closed = true;
    }
}
