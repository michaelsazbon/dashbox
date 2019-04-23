using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace DashBox.Models {
    
    public class Response {

        public Array Data { get; set; }
        public int Count { get; set; }
        public string Errors { get; set; }

        public Response(Array data, int count) {
            this.Data = data;
            this.Count = count;
        }

        public Response(string errors) {
            this.Errors = errors;
        }

        public Response() {

        }
    }
}