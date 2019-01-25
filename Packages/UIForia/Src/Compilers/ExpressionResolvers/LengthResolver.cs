using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using UIForia.Parsing;

namespace UIForia.Compilers {

    public class LengthResolver : ExpressionAliasResolver {

        private static readonly MethodInfo s_LengthVector1;
        private static readonly MethodInfo s_LengthVector2;

        static LengthResolver() {
            s_LengthVector1 = ReflectionUtil.GetMethodInfo(typeof(LengthResolver), nameof(FixedVec1));
            s_LengthVector2 = ReflectionUtil.GetMethodInfo(typeof(LengthResolver), nameof(FixedVec2));
        }

        public LengthResolver(string aliasName) : base(aliasName) { }

        public override Expression CompileAsMethodExpression(CompilerContext context, List<ASTNode> parameters) {
            if (context.targetType == typeof(FixedLengthVector)) {
                if (parameters.Count == 1) {
                    Expression expr = context.Visit(typeof(UIFixedLength), parameters[0]);
                    if (expr == null) {
                        throw new CompileException($"Invalid arguments for {aliasName}");
                    }

                    return new MethodCallExpression_Static<UIFixedLength, FixedLengthVector>(s_LengthVector1, new[] {expr});
                }

                if (parameters.Count == 2) {
                    Expression expr0 = context.Visit(typeof(UIFixedLength), parameters[0]);
                    Expression expr1 = context.Visit(typeof(UIFixedLength), parameters[1]);
                    if (expr0 == null || expr1 == null) {
                        throw new CompileException($"Invalid arguments for {aliasName}");
                    }

                    return new MethodCallExpression_Static<UIFixedLength, UIFixedLength, FixedLengthVector>(s_LengthVector2, new[] {expr0, expr1});
                }
            }

            if (context.targetType == typeof(UIFixedLength)) { }

            return null;
        }

        [Pure]
        public static FixedLengthVector FixedVec1(UIFixedLength x) {
            return new FixedLengthVector(x, x);
        }

        [Pure]
        public static FixedLengthVector FixedVec2(UIFixedLength x, UIFixedLength y) {
            return new FixedLengthVector(x, y);
        }

    }

}