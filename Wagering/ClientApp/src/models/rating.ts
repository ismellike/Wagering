interface Rating {
    id: number;
    gameUrl: string;
    game: Game | null;
    userId: string;
    user: ApplicationUser | null;
    value: number;
    gamesPlayed: number;
}
