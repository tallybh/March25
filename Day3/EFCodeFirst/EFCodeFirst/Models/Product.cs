﻿using System;
using System.Collections.Generic;

namespace EFCodeFirst.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string? Decription { get; set; }

    public int StoreId { get; set; }
}
