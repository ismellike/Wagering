export default class Games {
  games: Game[] = new Array();

  public constructor() {
    this.games.push(
      { id: 1, name: "Fortnite", normalizedName: "fortnite" },
      { id: 2, name: "Modern Warfare", normalizedName: "modern-warfare" }
    );
  }
  getId(game: string): number {
    game = game.toLowerCase();
    const entry = this.games.find((x) => x.normalizedName == game);
    return entry ? entry.id : 0;
  }
}
