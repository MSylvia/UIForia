using System;

namespace UIForia {

    public class StringLiteralNodeOld : LiteralValueNodeOld {

        public readonly string value;
        
        public StringLiteralNodeOld(string value) : base(ExpressionNodeType.LiteralValue) {
            this.value = value;
        }

        public override Type GetYieldedType(ContextDefinition context) {
            return typeof(string);
        }

    }

}