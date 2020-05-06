interface WagerNotification {
    id: number;
    wagerId: number;
    wager: Wager | null;
    notificationId: number;
    notification: GroupNotification | null;
}
