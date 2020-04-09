using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Head.Api.Models
{
    public class Post
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }

        public PostResponseModel ToResponseModel() {
            var post = new PostResponseModel
            {
                Title = Title,
                Content = Content,
                Id = Id,
                Location = new Coordinates
                {
                    Lat = Location.Coordinates.Latitude,
                    Long = Location.Coordinates.Longitude
                }
            };

            return post;
        }

        public static Post FromRequestModel(PostRequestModel source) {
            var post = new Post
            {
                Title = source.Title,
                Content = source.Content,
                Location = GeoJson.Point(new GeoJson2DGeographicCoordinates(source.Location.Lat, source.Location.Long))
            };

            return post;  
        }
    }
}
