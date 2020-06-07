# Monopoly Kata

Original credits to Brett L. Schuchert's [Monopoly Kata](http://schuchert.wikispaces.com/Katas.MonopolyTheGame(r)).

This example uses the game Monopoly as the basis for learning Object Oriented Design following both a Test Driven Development approach as well as a Test First Development approach. In this example we only use the game as a basis but change the rules as necessary to emphasize certain kinds of design problems.

This problem is different from the RPN Calculator in that we do not start with user stories but rather a description of each release. In a classroom setting, we'd start each release with a user story workshop to determine possible work. We'd then sequence the user stories and being implemented the user stories.

# Release 1: Basic Board and Player Movement

For this first release, we want to be able to support the basic player movement. All players start on the first location. The players' order is initially determined randomly and then maintained for the remainder of the game. Each player takes a turn, during which they roll a pair of dice, move from their current location to a destination calculated based on their current location plus the roll of the dice. The board has a total of 40 locations. When the player reaches the end of the board, s/he starts back at the beginning again. Since this version is so simple, we'll simply play a total of 20 rounds, where a round means every player takes a turn.

For a layout of the board, see [The Board](https://en.wikipedia.org/wiki/Monopoly_(game)#Atlantic_City_version).

The following stories along with their user acceptance tests cover release 1:

## User Story 1 - Player Movement

As a player, I can take a turn so that I can move around the board.

### User Acceptance Tests

- Player on beginning location (numbered 0), rolls 7, ends up on location 7
- Player on location numbered 39, rolls 6, ends up on location 5

## User Story 2 - Game Players

As a game, I can have between 2 and 8 players with an initial random ordering.

### User Acceptance Tests

- Create a game with two players named Horse and Car.
- Try to create a game with 8 players. When attempting to play the game, it will fail.
- Create a game with two players named Horse and Car. Within creating 100 games, both orders [Horse, Car] and [car, horse] occur.

## User Story 3 - Game Rounds

As a game, I execute 20 rounds so that I can complete a game.

### User Acceptance Tests

- Create a game and play, verify that the total rounds was 20 and that each player played 20 rounds.
- Create a game and play, verify that in every round the order of the players remained the same.

## Optional (Release 1)

Display the names of the locations rather than the number of the locations.

# Release 2: Go, Go To Jail, Income Tax, Luxury Tax

When a player lands on go, they receive $200. When a player passes go, they receive $200. Note they get the money at the time they land on or pass over go, not the next turn. The do not get any money for leaving go (e.g. during the first turn or if they landed on go the previous turn).

When a player lands on go to jail, they are moved directly to "Just Visiting". They do not receive any money for passing go since they went directly to just visiting. Note that we are making this simple for now, we deal with the details of jail later.

When a player lands on Income Tax, they must pay 20% of their net worth or $200, whichever is the smaller amount (a simplified version of the rule).
When a player lands on luxury tax, they must pay $75.

The following stories along with their user acceptance tests cover release 2:

## User Story 1 - Landing on Go

As a player, when I land on go I get $200 as my salary for staying in the game.

### User Acceptance Tests

- During a turn a Player lands on Go and their balance increases by $200.
- During a turn a Player lands on some "normal" location and their balance does not change.

## User Story 2 - Passing over Go

As a player, I receive $200 when I pass over Go.

### User Acceptance Tests

- Player starts before Go near the end of the Board, rolls enough to pass Go. The Player's balance increases by $200.
- Player starts on Go, takes a turn where the Player does not additionally land on or pass over Go. Their balance remains unchanged.
- Player passes go twice during a turn. Their balance increases by $200 each time for a total change of $400.

## User Story 3 - Landing on Go to Jail

As a Player, when I land on Go To Jail during a turn I move directly to Just Visiting.

### User Acceptance Tests

- Player starts before Go To Jail, lands on Go To Jail, ends up on Just Visiting and their balance is unchanged.
- Player starts before Go To Jail, rolls enough to pass over Go To Jail but not enough to land on or pass over go. Their balance is unchanged and they end up where the should based on what they rolled.

## User Story 4 - Landing on Income Tax

As a Player, landing on Income Tax forces me to pay the smaller of 10% of my total worth or $200.

### User Acceptance Tests

- During a turn, a Player with an initial total worth of $1800 lands on Income Tax. The balance decreases by $180.
- During a turn, a Player with an initial total worth of $2200 lands on Income Tax. The balance decreases by $200.
- During a turn, a Player with an initial total worth of $0 lands on Income Tax. The balance decreases by $0.
- During a turn, a Player with an initial total worth of $2000 lands on Income Tax. The balance decreases by $200.
- During a turn, a Player passes over Income Tax. Nothing happens.

## User Story 5 - Landing on Luxury Tax

As a Player, when I land on Luxury Tax, I pay $75.

### User Acceptance Tests

- Player takes a turn and lands on Luxury tax. Their balance decreases by $75.
- Player passes Luxury Tax during a turn. Their balance is unchanged.

## Optional (Release 2)

If you finish ahead of the class, work on the following:
- If a player's balance ever goes below 0, they lose. If you're playing with 2 players, the other player is announced as the winner. Setup your players to demonstrate this happening.
- Allow for more than 2 players. Have one player run out of money and the other 2 continue playing through the remainder of the 20 rounds.
- Allow for more than 2 players. Have all but one player run out of money over time (not all during the same turn). Announce the one remaining player as a winner.

# Release 3: Real Estate

Players can purchase railroads, utilities and Properties. When a player lands on unowned real estate, they immediately purchase it and the price is deducted from their balance (you can allow the player's balance to go below 0 or you can cancel the purchase if they cannot afford it).

When a player lands on an owned real estate, they must pay rent equal to the rent amount to the owner (assuming they are not the owner).

When a player lands on a mortgaged property, nothing happens.

A player has the option of mortgaging a property or paying off the mortgage of a property at the beginning of their turn or at the end of their turn.

Properties: If a player owns all of the properties in a color group, the rent doubles.

Utilities: If only one utility is owned, then rent is equal to 4 times the value currently shown on the dice. If both utilities are owned (not necessarily by the same person), then rent is equal to 10 times the value currently shown on the dice.

Railroads: If a player owns one railroad, rent is $25. If a player owns two, rent is $50, 3 is $100 and 4 is $200.

The following stories along with their user acceptance tests cover release 3:

## User Story 1 - Player Buys Property

As a player, I can buy an unowned property when I land on it during a turn.

### User Acceptance Tests

- Land on a Property that is not owned. After turn, property is owned and balance decreases by cost of property.
- Land on a Property that I own, nothing happens.
- Pass over an unowned Property, nothing happens.

## User Story 2 - Player Pays Rent

As a player, I pay rent when I land on a Property that is owned by someone else.

### User Acceptance Tests

- Land on a Property owned by other player, player pays rent to owner. Player's balance decreases by rent amount. Owners balance increases by rent amount.
  - If landing on Railroad, rent is 25, 50, 100, 200 depending on how many are owned by owner (1 - 4).
  - If landing on Utility and only one Utility owned, rent is 4 times current value on Dice.
  - If landing on Utility and both owned (not necessarily by same Player), rent is 10 times current value on Dice.
  - If landing on Real Estate and not all in the same Property Group are owned, rent is stated rent value.
  - If landing on Real Estate and Owner owns all in the same Property Group, rent is 2 times stated rent value.

## User Story 3 - Player Rolls Doubles

As a Player, I can roll doubles and continue my turn, landing on new Locations.

### User Acceptance Tests

- During a turn, Player starts on Go, roles doubles (6) and then non-doubles of 4. Final Location is 10. The player landed on a total of two locations.
- During a turn, Player does not roll doubles. Only moves equal single roll value. The player only lands on one Location.
- During a turn, Player rolls doubles twice, they move for a total of 3 roll values and land on a total of three locations.
- During a turn, Player rolls doubles three times, they end up on Just Visiting.

### Questions

For each of these tests, there could be several side effects:

- Player might buy property,
- Player might pay rent,
- Player might land on Go To Jail, etc.

Do you think we need to include these conditions in these test? Why or why not?

## User Story 4 - Player Mortgages Property

As a player, I can mortgage a property during my turn.

### User Acceptance Tests

- Player mortgaged property. Their balance increases by 90% of the original purchase price (always rounded down.
- Player tires to mortgage property that is already mortgaged. Fails.
- Player tires to mortgage property that is not owned. Fails.
- Player tries to mortgage property that they do not own. Fails.

## User Story 5 - Player Pays Back Mortgage

As a Player, I can pay back the mortgage on a property.

### User Acceptance Tests

- Player pays for mortgage. Player's balance decreases by 100% of the property value. Property no longer mortgaged.
- Player tries to pay for property that is not mortgaged. Fails.
- Player tries to pay for property that is not owned. Fails.
- Player tries to pay for property they do not own. Fails.

## User Story 6 - Game Offers Mortgage Options

As a game, I give each Player the option to mortgage properties or pay for mortgages at the beginning and end of their turn.

### User Acceptance Tests

- At beginning of turn, Player is given option to mortgage property and does so.
- At beginning of turn, Player is given option to mortgage property but does not.
- At beginning of turn, Player is given option to pay back mortgage and does so.
- At beginning of turn, Player is given option to pay back mortgage but does not.
- At end of turn, Player is given option to mortgage property and does so.
- At end of turn, Player is given option to mortgage property but does not.
- At end of turn, Player is given option to pay back mortgage and does so.
- At end of turn, Player is given option to pay back mortgage but does not.

## Optional (Release 3)

If a player rolls doubles, they get to continue their turn and roll again. If they roll doubles three times in a row, they go directly to jail immediately after rolling doubles a third time.

# Release 4: Jail

A player can land in jail when:

1. S/he lands on "go To Jail"
1. S/he draws a "Go To Jail" card
2. Throws doubles three times in a row

When a player goes to jail, s/he does not collect $200 for passing go since s/he moves directly to jail.

A player can get out of jail in any of the following ways:

1. By throwing Doubles on any of the next three turns after landing in Jail. If the player rolls doubles but does not pay (or use a get out of jail free card), then the player moves forward the number of locations indicated by the dice but does not continue rolling the dice.
1. By using a "Get out of Jail Free" card from another player. (A player can purchase a "Get out of Jail Free" card from another player.
1. By paying a $50 fine before throwing the dice, in which case the player is no "Just Visiting"

If a player is still in jail after rolling dice (and not paying a fine) on the third turn, they must pay $50 and
moves ahead the number of locations shown on the dice.

The following stories along with their user acceptance tests cover release 4:

## User Story 1 - Landing on Go to Jail

As a Player, when I land on Go To Jail, I go directly to Jail and do not pass Go.

### User Acceptance Tests

- Roll non-doubles, land on Go To Jail, player is in Jail, turn is over, balance is unchanged.
- Roll doubles, land on Go To Jail, player is in Jail, turn is over, balance is unchanged.
- Pass over Go To Jail, nothing happens.

## User Story 2 - Rolling Doubles 3 Times

As a player, when I roll doubles three times in a row during the same turn, I Go To Jail.

### User Acceptance Tests

- Roll doubles 3 times in a row, never pass or land on go. Balance is unchanged. Player is in Jail.
- Roll doubles 3 times in a row, pass or land on go during first two rolls. Balance increases by $200. Player is in Jail.
- Roll doubles 2 times in a row. Player is not in Jail.

## User Story 3 - Pay to Get Out of Jail

As a player, when I'm in Jail at the beginning of my turn I can pay $50 to take a normal turn.

### User Acceptance Tests

- In Jail, Player pays $50. Rolls doubles, moves and rolls again, balance decreased by $50.
- In Jail, Player pays $50. Rolls doubles, moves, does not roll a second time, balance decreased by $50.

## User Story 4 - Roll Doubles to Get Out of Jail

As a Player in Jail, I can try to roll doubles and get out of Jail for free.

### User Acceptance Tests

- In Jail turns 1/2, roll doubles. Move once, no more rolling/moving.
- In Jail, turn 1/2, do not roll doubles. Still in Jail.
- In Jail, turn 3, roll doubles. Move and don't roll again.
- In Jail, turn 3, do not roll doubles. Move, balance decreased by $50.

## User Story 5 - Game Offers Player Option to Pay to Get Out of Jail

As a game, if a Player is in jail when it is their turn, I give them the option of paying $50 to get out of Jail.

### User Acceptance Tests

- Player is in Jail at beginning of turn. Game offers player option to pay to get out of jail:
  - Player pays. Player moved to Just Visiting and takes normal turn.
  - Player does not pay, Player takes turn.

# Release 5: Community Chest and Chance

Community chest and chance each have a single stack of cards. There is one stack of cards shared by all community chest locations and one stack of cards shared by all chance locations. The order of the cards is initially determined randomly. Once determined, the order remains the same (this iteration skips the get out of jail free card).
When a player lands on either of these locations, the next card (from the top of the deck) is removed, the player must follow the instructions on the card. The card is the placed back onto the deck at the bottom.

The following stories along with their user acceptance tests cover release 5:

## User Story 1 - Player Lands On Chance or Community Chest

As a Player, when I land on Community Chest or Chance I must play a card.

### User Acceptance Tests

- Player passes over Community Chest, nothing happens.
- Player lands on Community Chest not rolling doubles. Player plays card. Card's effect happens. Card at bottom of stack of cards.
- Player lands on Community Chest rolling doubles. Player plays card. Cards' effect happens. Card at bottom of stack of cards:
  - Player continues rolling if it was roll 1/2 and they did not get the Go To Jail card.
  - Player does not continue rolling if it was roll 1/2 and they did get the Go To Jail card.

### Cards

There are several kinds of community chest and chance cards. To find out more, see:

- [List of Chance Cards](https://en.wikipedia.org/wiki/Monopoly_(game)#Chance)
- [List of Community Chest Cards](https://en.wikipedia.org/wiki/Monopoly_(game)#Community_Chest)
