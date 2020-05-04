interface WagerChallengeBid extends WagerBid {
    challengeId: number;
    challenge: WagerChallenge | null;
}
