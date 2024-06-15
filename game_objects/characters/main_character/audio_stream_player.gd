extends AudioStreamPlayer;

@export var AudioStreams : Array[AudioStream];

var  index : int = 0;
func _play() -> void:
	stream = AudioStreams[index];
	index += 1                  ;
	index %= AudioStreams.size();
	self.                 play();
	pass;
	
	
	
