use pokemon_unite;


INSERT INTO HeldItem(name, tierattribtype, tier1val, tier10val, tier20val, attrib1type, attrib1val, attrib2type, attrib2val, description) VALUES
ROW ("Aeos Cookie", 'HP', 100, 150, 200, 'HP', 240, NULL, NULL, "When you score a goal, your maximum HP is raised for the rest of the match by 100/150/200. (This bonus caps at 6 stacks)"),
ROW ("Assault Vest", 'HP', 0.09, 0.12, 0.15, 'HP', 270, 'SpD', 51, "Gain a shield against Sp. Attack damage while out of combat for 9%/12%/15% max HP (OoC is 5s after leaving combat). This shield must be fully broken before receiving another from Assault Vest."),
ROW ("Attack Weight", 'ATK', 6, 9, 12, 'ATK', 18, NULL, NULL, "When you score a goal, your Attack is raised by 6/9/12 for the rest of the match. (This bonus caps at 6 stacks)"),
ROW ("Buddy Barrier", 'HP', 0.15, 0.20, 0.25, 'HP', 450, NULL, NULL, "Grant a shield to you and a nearby ally with the lowest HP for 15%/20%/25% of your max HP when using your Unite Move. This shield does not get replaced if you are targeted from another ally, but instead refreshes the duration of your current shield. (5s duration - 30s cooldown)"),
ROW ("Choice Specs", 'SpA', 0.30, 0.35, 0.40, 'SpA', 39, NULL, NULL, "When dealing damage with a move, deal (40/50/60 + 30%/35%/40% Sp. Attack) as additional damage. This additional damage only applies to 1 target (8s cd)."),
ROW ("Drain Crown", 'Lifesteal', 0.06, 0.08, 0.10, 'HP', 120, 'ATK', 18, "Restores HP equal to 6%/8%/10% of damage dealt by auto attacks that are Attack damage (ie: not true damage). (Patch 1.8.1.4- Still does not recover HP when dealing damage to shields)"),
ROW ("Energy Amplifier", 'DMG', 0.07, 0.14, 0.21, 'Energy Rate', 0.06, 'Cooldown Reduction', 0.045, "After activating your Unite move, deal increased damage by 7%/14%/21% for a short time. (4s duration - 15s cooldown)"),
ROW ("Exp. Share", 'Exp/s', 3, 4, 5, 'HP', 240, 'Move Speed', 150, "Grants 3/4/5 experience points per second while the wearer has the fewest Exp. Points on their team. Additionally, when the wearer or nearby teammates defeat a wild Pokémon, nearby teammates gain slightly more Exp. Points from that wild Pokémon knockout."),
ROW ("Float Stone", 'Move Speed', 0.10, 0.15, 0.20, 'ATK', 24, 'Move Speed', 150, "Increases movement speed while out of combat by 10%/15%/20%. (OoC is 5s after leaving combat)"),
ROW ("Focus Band", 'HP Lost', 0.08, 0.11, 0.14, 'DEF', 30, 'SpD', 30, "Upon reaching below 25% HP, recover HP each second for 3s by 8%/11%/14% of your missing HP. (100/90/80s cooldown)"),
ROW ("Leftovers", 'Max HP/s', 0.01, 0.015, 0.02, 'HP', 360, 'HP/5s', 9, "Recovers health over time while out of combat by 1%/1.5%/2% HP/s (OoC is 5s after leaving combat)."),
ROW ("Muscle Band", 'Remaining HP', 0.01, 0.02, 0.03, 'ATK', 15, 'AS', 0.075, "Deal additional damage with basic attacks by 1%/2%/3% of the targets remaining HP, capped against players at 120/240/360 . 0.35s internal cooldown, tracked separately for each enemy."),
ROW ("Rapid-Fire Scarf", 'AS', 0.15, 0.225, 0.30, 'ATK', 12, 'AS', 0.09, "Every instance of auto attack damage applies a hidden "stack" for 3s. Stacks up to 3 times and the duration can be refreshed before it expires. The 3rd stack increases auto attack speed by 15%/22.5%/30% for 5s (10s cooldown). Gaining a stack incurs a .35s internal cooldown until another stack can be acquired."),
ROW ("Razor Claw", 'ATK', 0.40, 0.45, 0.50, 'ATK', 15, 'Crit Rate', 0.021, "After using a move, the next basic attack deals (10/15/20 + 40%/45%/50% Attack) additional damage to 1 target. This buff lasts for 3s. While this item is held by a Melee Pokémon, this basic attack also slows enemies by 30% for 1s (1.5s cooldown)."),
ROW ("Rescue Hood", 'Recovery Effects', 0.05, 0.075, 0.10, 'DEF', 30, 'SpD', 30, "Increases shield and recovery effect by 5%/7.5%/10% when they're granted to ally Pokémon."),
ROW ("Rocky Helmet", 'HP', 0.03, 0.04, 0.05, 'HP', 270, 'DEF', 51, "After receiving damage equal to or higher than 10% max HP in a single attack, deal percent damage based on your max HP (3%/4%/5%) to nearby enemies (2s cooldown)."),
ROW ("Scope Lens", 'Of ATK', 0.45, 0.60, 0.75, 'Crit Rate', 0.06, 'Crit Damage', 0.12, "Deals additional damage equal to 45%/60%/75% of your Attack stat when dealing a critical hit with a basic attack (1s cooldown)."),
ROW ("Score Shield", 'HP', 0.05, 0.075, 0.10, 'HP', 450, NULL, NULL, "Shields you while you attempt to score a goal. This shield will break before all other shields. Scoring cannot be interrupted while the shield remains active. (20s cooldown). Shield value is dependent on item level and Pokémon level."),
ROW ("Shell Bell", 'HP', 45, 60, 75, 'SpA', 24, 'Cooldown Reduction', 0.045, "Recover (45/60/75 + 35%/40%/45% Sp. Attack) HP when successfully landing a move (10s Cooldown)."),
ROW ("Slick Spoon", 'SpD Penetration', 0.10, 0.15, 0.20, 'HP', 210, 'SpA', 30, "Makes damage dealt by your Pokémon's Sp. Attack attacks ignore 10%/15%/20% of enemy Sp. Defense."),
ROW ("Sp. Atk Specs", 'SpA', 8, 12, 16, 'SpA', 24, NULL, NULL, "When you score a goal, your Sp. Attack is raised by 8/12/16 for the rest of the match (This bonus caps at 6 stacks)."),
ROW ("Weakness Policy", 'ATK', 0.02, 0.025, 0.03, 'HP', 210, 'ATK', 15, "Upon taking damage, apply a 2/2.5/3% Attack buff for up to 3s. Stacks up to 4 times and the duration can be refreshed before it expires."),
ROW ("Wise Glasses", 'SpA', 0.03, 0.05, 0.07, 'SpA', 39, NULL, NULL, "Further increase Sp. Attack by 3%/5%/7%.")


