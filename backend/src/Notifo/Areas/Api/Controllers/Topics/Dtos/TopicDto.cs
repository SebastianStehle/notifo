﻿// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NodaTime;
using Notifo.Domain.Topics;
using Notifo.Infrastructure.Reflection;

namespace Notifo.Areas.Api.Controllers.Topics.Dtos
{
    public sealed class TopicDto
    {
        private static readonly Dictionary<string, long> EmptyCounters = new Dictionary<string, long>();

        /// <summary>
        /// The topic path.
        /// </summary>
        [Required]
        public string Path { get; set; }

        /// <summary>
        /// THe last update to the topic.
        /// </summary>
        [Required]
        public Instant LastUpdate { get; set; }

        /// <summary>
        /// The statistics counters.
        /// </summary>
        [Required]
        public Dictionary<string, long> Counters { get; set; }

        public static TopicDto FromTopic(Topic topic)
        {
            var result = SimpleMapper.Map(topic, new TopicDto());

            result.Counters = topic.Counters ?? EmptyCounters;

            return result;
        }
    }
}
