const express = require('express');
const consign = require('consign');

const app = express();

consign()
    .include('controllers')
    .into(app)

app.listen(3001, () => console.log('server runnnig on port 3001'));