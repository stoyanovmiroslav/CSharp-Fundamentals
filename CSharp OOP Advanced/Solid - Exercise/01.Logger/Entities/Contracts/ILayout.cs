﻿using System;
using System.Collections.Generic;
using System.Text;

public interface ILayout
{
    string FormatError(IError error);
}