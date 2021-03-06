﻿using Raylib_cs;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // [core] module examples
            core_2d_camera_platformer.Main();
            core_2d_camera.Main();
            core_3d_camera_first_person.Main();
            core_3d_camera_free.Main();
            core_3d_camera_mode.Main();
            core_3d_picking.Main();
            core_basic_window.Main();
            core_custom_logging.Main();
            core_drop_files.Main();
            core_input_gamepad.Main();
            core_input_gestures.Main();
            core_input_keys.Main();
            core_input_mouse_wheel.Main();
            core_input_mouse.Main();
            core_input_multitouch.Main();
            core_random_values.Main();
            core_scissor_test.Main();
            core_storage_values.Main();
            core_vr_simulator.Main();
            core_window_letterbox.Main();
            core_world_screen.Main();

            // [shapes] module examples
            shapes_basic_shapes.Main();
            shapes_bouncing_ball.Main();
            shapes_collision_area.Main();
            shapes_colors_palette.Main();
            shapes_easings_ball_anim.Main();
            // shapes_easings_box_anim.Main();
            shapes_easings_rectangle_array.Main();
            shapes_following_eyes.Main();
            shapes_lines_bezier.Main();
            shapes_logo_raylib_anim.Main();
            shapes_logo_raylib.Main();
            shapes_rectangle_scaling.Main();

            // [textures] module examples
            textures_background_scrolling.Main();
            textures_bunnymark.Main();
            textures_image_9patch.Main();
            textures_image_drawing.Main();
            textures_image_generation.Main();
            textures_image_loading.Main();
            textures_image_processing.Main();
            textures_image_text.Main();
            textures_logo_raylib.Main();
            textures_mouse_painting.Main();
            textures_npatch_drawing.Main();
            textures_particles_blending.Main();
            textures_raw_data.Main();
            textures_rectangle.Main();
            textures_sprite_button.Main();
            textures_sprite_explosion.Main();
            textures_srcrec_dstrec.Main();
            textures_to_image.Main();

            // [text] module examples
            text_font_filters.Main();
            text_font_loading.Main();
            text_font_spritefont.Main();
            text_format_text.Main();
            text_input_box.Main();
            text_raylib_fonts.Main();
            text_rectangle_bounds.Main();
            text_writing_anim.Main();

            // [models] module examples
            models_animation.Main();
            models_billboard.Main();
            models_box_collisions.Main();
            models_cubicmap.Main();
            models_first_person_maze.Main();
            models_geometric_shapes.Main();
            models_heightmap.Main();
            models_loading.Main();
            models_material_pbr.Main();
            models_mesh_generation.Main();
            models_mesh_picking.Main();
            models_orthographic_projection.Main();
            models_rlgl_solar_system.Main();
            models_skybox.Main();
            models_waving_cubes.Main();
            models_yaw_pitch_roll.Main();

            // [shaders] module examples
            shaders_basic_lighting.Main();
            shaders_custom_uniform.Main();
            shaders_eratosthenes.Main();
            shaders_fog.Main();
            shaders_julia_set.Main();
            shaders_model_shader.Main();
            shaders_palette_switch.Main();
            shaders_postprocessing.Main();
            shaders_raymarching.Main();
            shaders_shapes_textures.Main();
            shaders_simple_mask.Main();
            shaders_texture_drawing.Main();
            shaders_texture_waves.Main();

            // [audio] module examples
            audio_module_playing.Main();
            audio_multichannel_sound.Main();
            audio_music_stream.Main();
            audio_raw_stream.Main();
            audio_sound_loading.Main();
        }
    }
}
