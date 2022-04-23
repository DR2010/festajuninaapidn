using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fjapifestajuninadn.Models;

[BsonIgnoreExtraElements]
public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }

    //[BsonElement("Name")]
    //[JsonPropertyName("Name")]
    public string clientname { get; set; }            // name of the dish - this is the KEY, must be unique
    public string clientid { get; set; }                     // type of dish, includes drinks and deserts
    public string atendente { get; set; }        // preco do prato multiplicar por 100 e nao ter digits
    public string date { get; set; }      // Gluten free dishes
    public string time { get; set; }  // Dairy Free dishes
    public string status { get; set; }   // Vegeterian dishes
    public string eventid { get; set; }  // Number of items initially available
    public string timestartserving { get; set; }// Currently available
    public string timeplaced { get; set; }// Image Name
    public string timecompleted { get; set; }              // Description of the plate
    public string timecancelled { get; set; }                // Descricao do prato
    public string eatmode { get; set; }             // Descricao do activity
    public string totalgeral { get; set; }             // Descricao do activity
    public Items[] items { get; set; }             // Descricao do activity

};

[BsonIgnoreExtraElements]
public class Items
{
    //public string? id { get; set; }             // Descricao do activity
    public string pratoname { get; set; }             // Descricao do activity
    public string quantidade { get; set; }             // Descricao do activity
    public string price { get; set; }             // Descricao do activity
    public string total { get; set; }             // Descricao do activity
    public string tax { get; set; }             // Descricao do activity

}

public class SearchCriteria
{
    public string clientid { get; set; }             // Descricao do activity
    public string date { get; set; }             // Descricao do activity
    public string time { get; set; }             // Descricao do activity
    public string status { get; set; }             // Descricao do activity
    public string eatmode { get; set; }             // Descricao do activity
    public string deliverymode { get; set; }             // Descricao do activity
    public string deliveryfee { get; set; }             // Descricao do activity
    public string deliverylocation { get; set; }             // Descricao do activity
    public string deliverycontactphone { get; set; }             // Descricao do activity

}

