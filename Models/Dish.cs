using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fjapifestajuninadn.Models;


[BsonIgnoreExtraElements]
public class Dish
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    //[JsonPropertyName("Name")]
    public string name { get; set; }            // name of the dish - this is the KEY, must be unique
    public string type { get; set; }                     // type of dish, includes drinks and deserts
    public string price { get; set; }        // preco do prato multiplicar por 100 e nao ter digits
    public string glutenfree { get; set; }      // Gluten free dishes
    public string dairyfree { get; set; }  // Dairy Free dishes
    public string vegetarian { get; set; }   // Vegeterian dishes
    public string initialavailable { get; set; }  // Number of items initially available
    public string currentavailable { get; set; }// Currently available
    public string imagename { get; set; }// Image Name
    public string description { get; set; }              // Description of the plate
    public string descricao { get; set; }                // Descricao do prato
    public string activitytype { get; set; }             // Descricao do activity
    public string imagebase64 { get; set; }             // Descricao do activity

};