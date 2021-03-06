// TS3AudioBot - An advanced Musicbot for Teamspeak 3
// Copyright (C) 2017  TS3AudioBot contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the Open Software License v. 3.0
//
// You should have received a copy of the Open Software License along with this
// program. If not, see <https://opensource.org/licenses/OSL-3.0>.

namespace TS3AudioBot.ResourceFactories
{
	public sealed class PlayResource
	{
		public AudioResource BaseData { get; }
		public string PlayUri { get; }

		public PlayResource(string uri, AudioResource baseData)
		{
			BaseData = baseData;
			PlayUri = uri;
		}

		public override string ToString() => BaseData.ToString();
	}

	public class AudioResource
	{
		/// <summary>The resource type.</summary>
		public AudioType AudioType { get; set; }
		/// <summary>An identifier to create the song. This id is uniqe among same <see cref="TS3AudioBot.AudioType"/> resources.</summary>
		public string ResourceId { get; set;  }
		/// <summary>The display title.</summary>
		public string ResourceTitle { get; set; }
		/// <summary>An identifier wich is unique among all <see cref="AudioResource"/> and <see cref="TS3AudioBot.AudioType"/>.</summary>
		public string UniqueId => ResourceId + AudioType.ToString();

		public AudioResource() { }

		public AudioResource(string resourceId, string resourceTitle, AudioType type)
		{
			ResourceId = resourceId;
			ResourceTitle = resourceTitle;
			AudioType = type;
		}

		public AudioResource(AudioResource copyResource)
		{
			ResourceId = copyResource.ResourceId;
			ResourceTitle = copyResource.ResourceTitle;
			AudioType = copyResource.AudioType;
		}

		public AudioResource WithName(string newName) => new AudioResource(ResourceId, newName, AudioType);

		public override bool Equals(object obj)
		{
			var other = obj as AudioResource;
			if (other == null)
				return false;

			return AudioType == other.AudioType
				&& ResourceId == other.ResourceId;
		}

		public override int GetHashCode()
		{
			int hash = 0x7FFFF + (int)AudioType;
			hash = (hash * 0x1FFFF) + ResourceId.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			return $"{AudioType} ID:{ResourceId}";
		}
	}
}
