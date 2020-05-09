interface Group extends Approvable {
    id?: number;
    gameUrl?: string;
    game?: Game | null;
    description?: string;
    date?: Date;
    isPrivate?: boolean;
    groupName?: string;
    groupLink?: string;
}
