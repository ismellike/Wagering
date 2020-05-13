interface Rating {
    id: number;
    gameUrl: string;
    game: Game | null;
    userId: string;
    user: Profile | null;
    value: number;
    gamesPlayed: number;
}
