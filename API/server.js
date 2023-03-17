const express = require('express')
const routes = require('./router/routes.js')
const port = process.env.PORT || 3000

const app = express()

app.use('/', routes)

app.get('*', (req,res) => {
    res.send(str.link('localhost:3000/DB'))
})

app.listen(port, () => {console.log("[+] server started!")})