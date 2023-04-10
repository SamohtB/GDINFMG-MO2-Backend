const mysql = require('mysql2');
const express = require("express");
const routes = require('./src/routes/routes.js');
require("dotenv").config();


const app = express();

app.use(routes);

app.listen(process.env.PORT, function()
{
    console.log("server is now listening...")
});

