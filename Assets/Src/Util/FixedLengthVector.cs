﻿using Src;

public struct FixedLengthVector {

    public readonly UIFixedLength x;
    public readonly UIFixedLength y;

    public FixedLengthVector(UIFixedLength x, UIFixedLength y) {
        this.x = x;
        this.y = y;
    }

    public static bool operator ==(FixedLengthVector self, FixedLengthVector other) {
        return self.x == other.x && self.y == other.y;
    }

    public static bool operator !=(FixedLengthVector self, FixedLengthVector other) {
        return !(self == other);
    }

    public bool IsDefined() {
        return x.IsDefined() && y.IsDefined();
    }

}