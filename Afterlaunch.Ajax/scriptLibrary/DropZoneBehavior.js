Type.registerNamespace('Custom.UI');

Custom.UI.DropZoneBehavior = function(value) {
    Custom.UI.DropZoneBehavior.initializeBase(this, [value]);
    }  
    
    Custom.UI.DropZoneBehavior.prototype = {
    initialize: function(){
        Custom.UI.DropZoneBehavior.callBaseMethod(this, 'initialize');
        // Register ourselves as a drop target.
        Sys.Preview.UI.DragDropManager.registerDropTarget(this);        
    },
   
    dispose: function(){
        Custom.UI.DropZoneBehavior.callBaseMethod(this, 'dispose');
    },
    
    // IDropTarget members.
    get_dropTargetElement: function() {
        return this.get_element();
    },
    drop: function(dragMode, type, data) { 
        alert('dropped');
    },
    canDrop: function(dragMode, dataType) {
        return true;
    },
    onDragEnterTarget: function(dragMode, type, data) {
    },
    onDragLeaveTarget: function(dragMode, type, data) {
    },
    onDragInTarget: function(dragMode, type, data) {
    }
}


Custom.UI.DropZoneBehavior.registerClass('Custom.UI.DropZoneBehavior', Sys.UI.Behavior, Sys.Preview.UI.IDragSource, Sys.Preview.UI.IDropTarget, Sys.IDisposable);

if(typeof(Sys) !== "undefined")
  Sys.Application.notifyScriptLoaded();