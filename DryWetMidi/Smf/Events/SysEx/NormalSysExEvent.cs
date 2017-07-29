﻿using System;

namespace Melanchall.DryWetMidi.Smf
{
    /// <summary>
    /// Represents a normal system exclusive event.
    /// </summary>
    /// <remarks>
    /// A MIDI event that carries the MIDI system exclusive message, also known as a "MIDI sysex message",
    /// carries information that is specific to the manufacturer of the MIDI device receiving the message.
    /// The action that this message prompts for can be anything.
    /// Note that although the terminal 0xF7 is redundant (strictly speaking, due to the use of a length
    /// parameter) it must be included.
    /// System exclisive events can be splitted into multiple packets. In this case the first packet uses
    /// the 0xF0 status (such event will be read as <see cref="NormalSysExEvent"/>), whereas the second and
    /// subsequent packets use the 0xF7 status (suzh events will be read as <see cref="EscapeSysExEvent"/>).
    /// This use of the 0xF7 status is referred to as a continuation event.
    /// </remarks>
    public sealed class NormalSysExEvent : SysExEvent, IEquatable<NormalSysExEvent>
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalSysExEvent"/>.
        /// </summary>
        public NormalSysExEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NormalSysExEvent"/> with the
        /// specified data.
        /// </summary>
        /// <param name="data">Data of the sysex event.</param>
        public NormalSysExEvent(byte[] data)
        {
            Data = data;
        }

        #endregion

        #region IEquatable<NormalSysExEvent>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="normalSysExEvent">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(NormalSysExEvent normalSysExEvent)
        {
            return Equals(normalSysExEvent, true);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Determines whether the specified event is equal to the current one.
        /// </summary>
        /// <param name="midiEvent">The event to compare with the current one.</param>
        /// <param name="respectDeltaTime">If true the delta-times will be taken into an account
        /// while comparing events; if false - delta-times will be ignored.</param>
        /// <returns>true if the specified event is equal to the current one; otherwise, false.</returns>
        public override bool Equals(MidiEvent midiEvent, bool respectDeltaTime)
        {
            return Equals(midiEvent as NormalSysExEvent, respectDeltaTime);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Normal SysEx";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as NormalSysExEvent);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
