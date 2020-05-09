interface PersonalNotification {
    id?: number;
    userId?: string | null;
    user?: ApplicationUser | null;
    message: string;
    date: Date;
    link?: string | null;
}
