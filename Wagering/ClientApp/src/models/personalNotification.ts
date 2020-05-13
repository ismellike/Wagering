interface PersonalNotification {
    id: number;
    userId?: string;
    user?: Profile | null;
    message: string;
    date: Date;
    dataModel: number;
    data: string | null;
}
