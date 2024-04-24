mat3 rotateX(float theta)
{
	float cosa = cos(theta);
	float sina = sin(theta);

    //Y rotation
	mat3 rotate_x = mat3
	(
	   vec3(+1.0, +0.0 , +0.0 ),
	   vec3(+0.0, +cosa, -sina),
	   vec3(+0.0, +sina, +cosa)
	);

	return rotate_x;
}

mat3 rotateY(float theta)
{
	float cosa = cos(theta);
	float sina = sin(theta);

    //Y rotation
	mat3 rotate_y = mat3
	(
	   vec3(+cosa, +0.0, +sina),
	   vec3(+ 0.0, +1.0, + 0.0),
	   vec3(-sina, +0.0, +cosa)
	);

	return rotate_y;
}

mat3 rotateZ(float theta)
{
	float cosa = cos(theta);
	float sina = sin(theta);

    //Y rotation
	mat3 rotate_z = mat3
	(
	   vec3(+cosa, -sina, +0.0),
	   vec3(+sina, +cosa, +0.0),
	   vec3(+ 0.0, + 0.0, +1.0)
	);

	return rotate_z;
}

//EXAMPLE

//mat3 rotation_matrix = rotateX(PI / 2.0) * rotateY(0.0) * rotateZ(0.0);
//vec3 rotated_vertex = rotation_matrix * VERTEX;
//vec3 rotated_normal = rotation_matrix * NORMAL;
//
//VERTEX = rotated_vertex;
//NORMAL = rotated_normal;