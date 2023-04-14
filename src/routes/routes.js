const express = require("express");
const db = require("../db/db.js");
const bodyParser = require("body-parser");
const mysql = require('mysql2/promise');
const router = express.Router();

router.use(bodyParser.json());

//1 Get All Pokemon Sprites - For main pokemon list
router.get("/pokemon", (req, res) => 
{
    const promise = [
        db.AllPokemon()
    ];

    Promise.all(promise)
        .then((results) => {
            const pokemon = results[0];
            const response = {
                All_Pokemon : pokemon
            };
        
        console.log(response);
        res.json(response);

        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching all Pokemon");
        });
});

//2 Get Filtered Pokemon and Count- When Filter is Called
router.get("/pokemon/:AttackType.:AttackStyle.:Role.:Complexity", (req, res) => 
{
    const filterValues = [req.params.AttackType, req.params.AttackStyle, req.params.Role, req.params.Complexity];
    const promises = [
        db.FilteredPokemon(filterValues),
        db.FilteredCountPokemon(filterValues)
    ];

    Promise.all(promises)
        .then((results) => {
            const pokemon = results[0][0];
            const count = results[1];
            const response = {
                pokemon : pokemon,
                count : count
            };
        
        console.log(response);
        res.json(response);

        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching filtered Pokemon");
        });
});

//3 Get Specific Pokemon with stats and skills
router.get("/pokemon/:PokemonId", (req, res) => 
{
    const pokemonID = [req.params.PokemonId];
    const promises = [
        db.OnePokemon_Pokemon(pokemonID),
        db.OnePokemon_Stats(pokemonID),
        db.OnePokemon_Skills(pokemonID)
    ];

    Promise.all(promises)
        .then((results) => {
            const pokemon = results[0][0];
            const stats = results[1];
            const skills = results[2];
            const response = {
                pokemon : pokemon,
                stats : stats,
                skills : skills
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Pokemon");
        });
});

//4 Get All Items
router.get("/Items", (req, res) => 
{
    const promises = [
        db.AllBattle(),
        db.AllHeld()
    ];

    Promise.all(promises)
        .then((results) => {
            const battleitems = results[0];
            const helditems = results[1];
            const response = {
                battleitems : battleitems,
                helditems : helditems
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Pokemon");
    });
})

//5 Get One Battle Item
router.get("/Items/Battle/:BattleId", (req, res) =>
{
    const values = [req.params.BattleId];
    const promises = [
        db.OneBattle(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const battleitem = results[0];
            const response = {
                battleitem : battleitem,
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Battle Item");
    });
    
});


//6 Get One Held Item
router.get("/Items/Held/:HeldId", (req, res) =>
{
    const values = [req.params.HeldId];
    const promises = [
        db.OneHeld(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const HeldItem = results[0];
            const response = {
                helditem : HeldItem,
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Held Item");
    });
});

//7 Get All BoostEmblem
router.get("/Emblems", (req, res) =>
{
    const promises = [
        db.AllEmblems()
    ];

    Promise.all(promises)
        .then((results) => {
            const Emblems = results[0];
            const response = {
                BoostEmblems : Emblems,
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Boost Emblems");
    });
});

//7 get specific
router.get("/Emblems/:Name", (req, res) => 
{
    const values = [req.params.Name];
    const promises = [
        db.OneEmblem(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Emblems = results[0];
            const response = {
                BoostEmblems : Emblems
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Boost Emblem");
    });
})

//8 Get Filtered Emblems
router.get("/Emblems/:Color.:IncreasedStat", (req, res) =>
{
    const values = [req.params.Color, req.params.IncreasedStat];
    const promises = [
        db.FilteredEmblems(values),
        db.FilteredCountEmblems(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Emblems = results[0];
            const Count = results[1];
            const response = {
                BoostEmblems : Emblems,
                EmblemCount : Count
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Filtered Boost Emblems");
    });
});

//9 Get All Emblem Loadouts
router.get("/Emblems/Loadout", (req, res) =>
{
    const promises = [
        db.AllLoadout()
    ];

    Promise.all(promises)
        .then((results) => {
            const Loadouts = results[0];
            const response = {
                EmblemLoadouts : Loadouts,
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Boost Emblem Loadouts");
    });
});

//9 Get One Emblem Loadout
router.get("/Emblems/Loadout/:LoadoutId", (req, res) =>
{
    const values = [req.params.LoadoutId];
    const promises = [
        db.OneLoadout(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Loadouts = results[0];
            const response = {
                EmblemLoadouts : Loadouts,
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error fetching Boost Emblem Loadout");
    });
});

//9 Create Emblem Loadout
router.post("/Emblems/Loadout", (req, res) =>
{
    const name = [req.body.name];
    const emblems = [
      req.body.emblem1,
      req.body.emblem2,
      req.body.emblem3,
      req.body.emblem4,
      req.body.emblem5,
      req.body.emblem6,
      req.body.emblem7,
      req.body.emblem8,
      req.body.emblem9,
      req.body.emblem10
    ];
  
    db.CreateLoadout(name)
      .then((loadoutId) => {
        return db.InsertEmblem(loadoutId, emblems);
      })
      .then(() => {
        const response = {
          EmblemLoadouts: { name },
          EmblemSlots: emblems
        };
        console.log(response);
        res.send(response);
      })
      .catch((error) => {
        console.error("An error occurred: ", error);
        res.status(500).send("Error creating Boost Emblem Loadout");
      });
});

//9 updates name only
router.put("/Emblems/Loadout", (req, res) =>
{
    const name = {
        "loadoutid" : req.body.loadoutid, 
        "name" : req.body.name,
    }

    const promises = [
        db.UpdateLoadout(name)
    ];

    Promise.all(promises)
        .then((results) => {
            const Loadouts = results[0];
            const response = {
                UpdatedLoadouts : Loadouts
            };

            console.log(response);
            res.send(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error updating Boost Emblem Loadout");
    });

});

//9 delete
router.delete("/Emblems/Loadout", (req, res) =>
{
    const values = [
        req.body.loadoutid
    ]

    const promises = [
        db.DeleteLoadout(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Loadouts = results[0];
            const response = {
                UpdatedLoadouts : Loadouts
            };

            console.log(response);
            res.send(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error updating Boost Emblem Loadout");
    });

});

//10 Get Build of Certain Pokemon
router.get("/Build/:PokemonId", (req, res) =>
{
    const values = [req.params.PokemonId];
    const promises = [
        db.Builds(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Builds = results[0];
            const response = {
                Builds : Builds
            };

            console.log(response);
            res.json(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error getting Pokemon Builds");
    });
});

//10 Create Build
router.post("/Build", (req, res) =>
{
    values = [
        req.body.ownerid, 
        req.body.name, 
        req.body.move1, 
        req.body.move2, 
        req.body.helditem1id, 
        req.body.helditem2id, 
        req.body.helditem3id, 
        req.body.battleitemid,
        req.body.loadoutid
    ];

    const promises = [
        db.CreateBuild(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Builds = results[0];
            const response = {
                Builds : Builds
            };

            console.log(response);
            res.send(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error creating Pokemon Builds");
    });
});

//10 Update Build of Certain Pokemon
router.put("/Build", (req, res) =>
{
    const values = {
        buildid: req.body.buildid,
        ownerid: req.body.ownerid,
        name: req.body.name,
        move1: req.body.move1,
        move2: req.body.move2,
        helditem1id: req.body.helditem1id,
        helditem2id: req.body.helditem2id,
        helditem3id: req.body.helditem3id,
        battleitemid: req.body.battleitemid,
        loadoutid: req.body.loadoutid
    };

    const promises = [
        db.UpdateBuild(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Builds = results[0];
            const response = {
                Builds : Builds
            };

            console.log(response);
            res.send(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error updating Pokemon Builds");
    });
});

//10 Delete Build of Certain Pokemon
router.delete("/Build", (req, res) =>
{
    const values = [req.body.buildid];
    const promises = [
        db.DeleteBuild(values)
    ];

    Promise.all(promises)
        .then((results) => {
            const Builds = results[0];
            const response = {
                Builds : Builds
            };

            console.log(response);
            res.send(response);
        })
        .catch((error) => {
            console.error("An error occured: ", error);
            return res.status(500).send("Error deleting Pokemon Builds");
    });

});


module.exports = router;