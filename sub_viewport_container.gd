extends SubViewportContainer;

func                 _input(event):
	$SubViewport.push_input(event);
	pass;

func                 _unhandled_input(event):
	$SubViewport.push_unhandled_input(event);
	pass;
	
	
	
	
	
	
