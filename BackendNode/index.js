const customExpress = require('./config/customExpress');

const app = customExpress();

app.listen(3001, () => console.log('server runnnig on port 3001'));