// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JoinResponse.cs" company="Exit Games GmbH">
//   Copyright (c) Exit Games GmbH.  All rights reserved.
// </copyright>
// <summary>
//   Defines the JoinResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Photon.Hive.Operations
{
    #region

    using System.Collections;
    using System.Collections.Generic;
    using Photon.SocketServer.Rpc;

    #endregion

    public class ObjectResponse
    {
        #region Properties

        [DataMember(Code = (byte)ParameterKey.Objects, IsOptional = true)]
        public Dictionary<string, Hashtable> CurrentRoomObjects { get; set; }

        #endregion
    }
}