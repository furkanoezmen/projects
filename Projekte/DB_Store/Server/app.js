const express= require("express");
const bodyParser= require("body-parser");
const engines= require("consolidate");
const paypal= require("paypal-rest-sdk");
var fs = require('fs');
var QRCode = require('qrcode');
const { Console } = require("console");
const { resolve } = require("bluebird");
const cons = require("consolidate");
var helmet = require('helmet');
const crypto = require('crypto')

function encrypt (text, key) {
  try {
    const IV_LENGTH = 16 // For AES, this is always 16
    let iv = crypto.randomBytes(IV_LENGTH)
    let cipher = crypto.createCipheriv('aes-256-cbc', Buffer.from(key), iv)
    let encrypted = cipher.update(text)

    encrypted = Buffer.concat([encrypted, cipher.final()])
    console.log(iv.toString('hex'))
    return iv.toString('hex') + ':' + encrypted.toString('hex')
  } catch (err) {
    throw err
  }
}

function decrypt (text, key) {
  try {
    let textParts = text.split(':')
    let iv = Buffer.from(textParts.shift(), 'hex')
    let encryptedText = Buffer.from(textParts.join(':'), 'hex')
    let decipher = crypto.createDecipheriv('aes-256-cbc', Buffer.from(key), iv)
    let decrypted = decipher.update(encryptedText)

    decrypted = Buffer.concat([decrypted, decipher.final()])

    return decrypted.toString()
  } catch (err) {
    throw err
  }
}

var key = "YFpoGQ@$VrUMf64tZ9eg^RiaQSZ^Pw%*"


var price = JSON.parse(fs.readFileSync('preise.json', 'utf8'));


const app= express();



app.engine("ejs", engines.ejs);

app.set("view engine","ejs");

app.use((req, res, next) => {
    res.setHeader("X-XSS-Protection", "1; mode=block");
    next();
  });
app.use(helmet({
    xssFilter: false,
  }));
app.use(  helmet.contentSecurityPolicy({
    directives: {
        defaultSrc: ["'self'"],
        imgSrc: ["Db-bahn.png"],
        styleSrc: ["https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css", "'self'"],
        scriptSrc: ["'self'"],
        frameAncestors: ["'self'"]
    }
  }),
);
app.use(helmet.dnsPrefetchControl());
app.use(helmet.expectCt());
app.use(helmet.frameguard());
app.use(helmet.hidePoweredBy());
app.use(helmet.hsts());
app.use(helmet.ieNoOpen());
app.use(helmet.noSniff());
app.use(helmet.permittedCrossDomainPolicies());
app.use(helmet.referrerPolicy());

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
app.use(express.static("views"));
var speicher={
    automatid:[{id:"222",start: "", ziel: "", preis: "",status: ""},
                {id:"223",start: "", ziel: "", preis: "",status: ""}]
};



app.post('/', function(request, response) {
    
    console.log(request.body)
    var id = decrypt(request.body.abc, key)
    var start=decrypt(request.body.def, key)
    var ziel=decrypt(request.body.ghi, key)
    var ticketart=decrypt(request.body.jkl, key)
    console.log(id+'   Auswahl getroffen   '+start+ "   Startpunkt   "+ziel+"   Ziel   "+ticketart+"   Ticketart!  ");
    var preis;

    for(var i = 0; i < price.route[0].rb25[0].startpunkte.length; i++){
        
        if(price.route[0].rb25[0].startpunkte[i].start==start){
            
            for(var j = 0; j < price.route[0].rb25[0].startpunkte[i].ziele.length; j++){
                if(price.route[0].rb25[0].startpunkte[i].ziele[j].ziel==ziel){
                   
                    for(var z = 0; z < price.route[0].rb25[0].startpunkte[i].ziele[j].ticketart.length; z++){
                        if(price.route[0].rb25[0].startpunkte[i].ziele[j].ticketart[z].ticket==ticketart){
                            preis=price.route[0].rb25[0].startpunkte[i].ziele[j].ticketart[z].preis;
                            
                            
                                    for(var u=0; u<speicher.automatid.length;u++){

                                        if(speicher.automatid[u].id==id){
                                            speicher.automatid.splice(u,1,{id:id,start: start, ziel:ziel, preis: preis,status:"create"});
                                            var json= JSON.stringify(speicher);
                                            fs.writeFileSync('ticket.json', json);
                                        }
                                    }
                                }
                             }
                        }
 
                    }
            }
}
 

    response.writeHead(200, {'Content-Type': 'text/html'});
    preis=encrypt(preis, key);
    response.end(preis);
    
  });


paypal.configure({
    'mode': 'sandbox',
    'client_id': 'AekdQCvI7nDR70P6Rc0O22AOPyAaj9gPfyGfRDOUHGRU-AehH2B06RoOfSGOEu0_nKIZv4x0lFPtQtdc',
    'client_secret':'EBAA5mfRFCTc5myuh1DvAUKtFLHtJMoO4vYUAdiaUMS7H1FRfCsLLFdqvBmpm1UcfprDD7kU1n5NPeG6'

})


app.get("/", (req, res) => {
    console.log('GET/');
    res.render('index');
   
});
app.get("/robots.txt", (req, res) => {
    console.log('robot');
    res.render('robot');
   
});
app.get("/sitemap.xml", (req, res) => {
    console.log('sitemap');
    res.render('sitemap');
   
});


app.get("/:automatid/paypal", (req, res)=>{
    var ticket = JSON.parse(fs.readFileSync('ticket.json', 'utf8'));
    var automatid= req.params.automatid;
    

    var preis="";
    var ziel="";
    for(var u=0; u<ticket.automatid.length;u++){
        if(ticket.automatid[u].id==automatid){
            preis=ticket.automatid[u].preis;
            ziel=ticket.automatid[u].ziel;
        }
    }
    console.log("Automat: "+automatid+" Einkauf für: "+preis);

    var create_payment_json = {
        "intent": "sale",
        "payer": {
            "payment_method": "paypal"
        },
        "redirect_urls": {
            "return_url": "http://192.168.178.43:3000/"+automatid+"/success",
            "cancel_url": "http://192.168.178.43:3000/"+automatid+"/cancel"
        },
        "transactions": [{
            "item_list": {
                "items": [{
                   "name": ziel,
                    "sku": "item",
                    "price": preis,
                    "currency": "EUR",
                    "quantity": 1
                }]
            },
            "amount": {
                "currency": "EUR",
                    "total": preis
            },
            "description": "This is the payment description."
        }]
    };

    paypal.payment.create(create_payment_json, function (error, payment) {
        if (error) {
            throw error;
        } else {
            console.log("Automat: "+automatid+" hat die nötigen Links");
            var link=payment.links[1].href;
            link=encrypt(link, key);
            res.status(200).send(link);   
        }
    });

});
app.get('/:automatid/success', (req, res) => {
    const payerId = req.query.PayerID;
    const paymentId = req.query.paymentId;
    var automatid= req.params.automatid;
    var preis="";
    var ticket = JSON.parse(fs.readFileSync('ticket.json', 'utf8'));
    for(var u=0; u<ticket.automatid.length;u++){
        if(ticket.automatid[u].id==automatid){
            preis=ticket.automatid[u].preis;
        }
    }
    const execute_payment_json = {
      "payer_id": payerId,
      "transactions": [{
          "amount": {
              "currency": "EUR",
              "total": preis
          }
      }]
    };
  
    paypal.payment.execute(paymentId, execute_payment_json, function (error, payment) {
      if (error) {
          console.log(error.response);
          throw error;
      } else {

       
        for(var u=0; u<ticket.automatid.length;u++){
            if(ticket.automatid[u].id==automatid){
                
                ticket.automatid.splice(u,1,{id:ticket.automatid[u].id,start: ticket.automatid[u].start, ziel:ticket.automatid[u].ziel, preis: ticket.automatid[u].preis,status: "approval"});
                var json= JSON.stringify(ticket);
                fs.writeFileSync('ticket.json', json);
            }
        }
        console.log("Automat: "+automatid+" erfolgreicher Einkauf");
        res.redirect('/');
      }
  });
  });

app.get('/:automatid/cancel',(req, res) =>{
    var automatid= req.params.automatid;
    for(var u=0; u<ticket.automatid.length;u++){
        if(ticket.automatid[u].id==automatid){
            
            ticket.automatid.splice(u,1,{id:ticket.automatid[u].id,start: ticket.automatid[u].start, ziel:ticket.automatid[u].ziel, preis: ticket.automatid[u].preis,status: "failed"});
            var json= JSON.stringify(ticket);
            fs.writeFileSync('ticket.json', json);
        }
    }
});

app.get('/:automatid/abschluss',(req, res) =>{
    var ticket = JSON.parse(fs.readFileSync('ticket.json', 'utf8'));
    var automatid= req.params.automatid;
    
    for(var u=0; u<ticket.automatid.length;u++){
        if(ticket.automatid[u].id==automatid){
            if(ticket.automatid[u].status!="create"){
                console.log("Automat: "+automatid+" Einkauf abgeschlossen");
                var status=ticket.automatid[u].status;
                status=encrypt(status, key);
                res.status(200).send((status).toString());
                ticket.automatid.splice(u,1,{id:ticket.automatid[u].id,start: "", ziel:"", preis: "",status: ""});
                var json= JSON.stringify(ticket);
                fs.writeFileSync('ticket.json', json);
            }else{
                var status=ticket.automatid[u].status;
                status=encrypt(status, key);
                res.status(200).send((status).toString());
            }


        }
    }

});

app.listen(3000, () =>{
    console.log("Server is running");
});