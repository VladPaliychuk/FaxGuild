﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int? Likes { get; set; }
        public string AuthorID { get; set; }
        public string Picture { get; set; }
        public DateTime CreateTime { get; set; }
    }
}