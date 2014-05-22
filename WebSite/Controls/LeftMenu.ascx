<%@ Control Language="C#" AutoEventWireup="true" Inherits="Yaesoft.DSI.Web.LeftMenu" %>
<script type="text/javascript">
<!--
    $(function () {
        var t = $("#<%=this.ClientID%>_tree").tree({
            data:<%=JsonData%>,
            lines:true,
            formatter:function(node){
                return "<a href='"+ node.attributes.url+"' target='_self'>"+node.text+"</a>"
            }
        });
        var node = t.tree("find", "<%=this.CurrentFolderID%>");
        if(node){
            t.tree("select",node.target);
        }
    });
//-->
</script>
<ul id="<%=this.ClientID%>_tree"></ul>