﻿using System;
using System.Collections.Generic;
using SiteServer.Plugin.Models;

namespace SiteServer.Plugin.Apis
{
    public interface INodeApi
    {
        INodeInfo GetNodeInfo(int publishmentSystemId, int channelId);
    }
}
