interface PersonalNotification {
    id: number;
    userId?: string;
    user?: ApplicationUser | null;
    message: string;
    date: Date;
    dataModel: number;
    data: string | null;
}
