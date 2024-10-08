extends Node;

@onready var _anim_player := $AnimationPlayer;
@onready var _track_1 := $AmbientSound01;
@onready var _track_2 := $AmbientSound02;

func crossfade_to(audio_stream: AudioStream) -> void:
	if (_track_1.playing
	and _track_2.playing):
		return;

	if (_track_2.playing):
		_track_1.stream = audio_stream;
		_track_1.    play(              );
		_anim_player.play("FADE_TO_AMBIENT_SOUND_01");
	else:
		_track_2.stream = audio_stream;
		_track_2.    play(              );
		_anim_player.play("FADE_TO_AMBIENT_SOUND_02");
