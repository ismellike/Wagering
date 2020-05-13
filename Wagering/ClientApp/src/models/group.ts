interface Group extends Approvable {
    id?: number;
    gameId?: number;
    game?: Game | null;
    description?: string;
    date?: Date;
    isPrivate?: boolean;
    groupName?: string;
}
