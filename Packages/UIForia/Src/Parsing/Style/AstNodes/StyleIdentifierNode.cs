namespace UIForia.Style.Parsing {

    public class IdentifierNode : ASTNode {

        public string name;
        
        public bool IsAlias => name[0] == '$';

        public override void Release() {
            s_IdentifierPool.Release(this);
        }

    }

}