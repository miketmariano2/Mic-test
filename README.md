# Mic-test Level_Design Branch

Changes made in consolidation pre 5PM build on 10/19:
- consolidated echolocation shader branch with Joi's level branch
- lightly modded FPS controller
- echolocation generation is now through pressing the key m (stand in for mic)
- main branch of Mike's mic input does not seem to register audio on Momo's device (main branch). For now the attached script component is unattached on the FPS controller
- consolidated the location of scenes, files, scripts (that's what the delete commits are for for redundancy), made prefabs for ease of use/updating etc
- assigned dark_material to Joi's level mesh

The player can now move around, look around and generate ripples with the m key. Sort out mic registration on separate devices in class. 
Necessary Packages are ShaderGraph + Probuilder
