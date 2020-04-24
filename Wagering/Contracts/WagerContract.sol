pragma solidity ^0.6.4;


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
    Bid[] public bids;
    uint256 public totalTeams;

    modifier onlyOwner {
        //wagering.gg is owner
        require(msg.sender == owner, "Only contract owner can call this.");
        _;
    }

    constructor(
        address payable[] memory _addresses,
        uint8[] memory _percentages,
        uint8[] memory _teams,
        uint256 _totalTeams
    ) public {
        require(_totalTeams > 1, "At least 2 teams must participate.");
        uint256 length = _addresses.length;
        totalTeams = _totalTeams;
        require(length == _percentages.length, "Array lengths must be equal.");
        require(length == _teams.length, "Array lengths must be equal.");
        for (uint256 i = 0; i < length; i++) {
            require(
                _teams[i] >= _totalTeams,
                "A team is not within the total teams count."
            );
            bids.push(Bid(_addresses[i], _percentages[i], _teams[i]));
        }
    }

    function cancel() public payable onlyOwner {}
}
