const express= require("express");
const bodyParser= require("body-parser");
const engines= require("consolidate");
const paypal= require("paypal-rest-sdk");
var fs = require('fs');
var QRCode = require('qrcode');
const { Console } = require("console");
const { resolve } = require("bluebird");
const cons = require("consolidate");



var price = JSON.parse(fs.readFileSync('preise.json', 'utf8'));


const app= express();



app.engine("ejs", engines.ejs);

app.set("view engine","ejs");

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
app.use(express.static("views"));
var speicher={
    automatid:[{id:"222",start: "", ziel: "", preis: "",status: ""},
                {id:"223",start: "", ziel: "", preis: "",status: ""}]
};



app.post('/', function(request, response) {
    console.log(request.body.id+' Auswahl getroffen');

    var preis;

    for(var i = 0; i < price.route[0].rb25[0].startpunkte.length; i++){
        if(price.route[0].rb25[0].startpunkte[i].start==request.body.start){
            
            for(var j = 0; j < price.route[0].rb25[0].startpunkte[i].ziele.length; j++){
                if(price.route[0].rb25[0].startpunkte[i].ziele[j].ziel==request.body.ziel){
                    
                    for(var z = 0; z < price.route[0].rb25[0].startpunkte[i].ziele[j].ticketart.length; z++){

                        if(price.route[0].rb25[0].startpunkte[i].ziele[j].ticketart[z].ticket==request.body.ticketart){
                            preis=price.route[0].rb25[0].startpunkte[i].ziele[j].ticketart[z].preis;
                            
                            
                            
                                    for(var u=0; u<speicher.automatid.length;u++){

                                        if(speicher.automatid[u].id==request.body.id){
                                            speicher.automatid.splice(u,1,{id:request.body.id,start: request.body.start, ziel:request.body.ziel, preis: preis,status:"create"});
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
 

    response.writeHead(200, {'Content-Type': 'text/html'})
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
            console.log(payment.links[1].href);
            res.status(200).send(payment.links[1].href+"+"+payment.id);   
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
                res.status(200).send((ticket.automatid[u].status).toString());
                ticket.automatid.splice(u,1,{id:ticket.automatid[u].id,start: "", ziel:"", preis: "",status: ""});
                var json= JSON.stringify(ticket);
                fs.writeFileSync('ticket.json', json);
            }else{
                res.status(200).send((ticket.automatid[u].status).toString());
            }


        }
    }

});

app.listen(3000, () =>{
    console.log("Server is running");
});