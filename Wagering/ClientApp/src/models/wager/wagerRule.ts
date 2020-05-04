interface WagerRule {
    id: number;
    ruleId: number;
    rule: Rule | null;
    wagerId: number;
    wager: Wager | null;
}
