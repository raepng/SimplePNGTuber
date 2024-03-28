# SimplePNGTuber
This is yet another PNGTuber software. Its purpose is to be just a small application but with some interesting features that other simple PNGTuber softwares usually dont have.
It has an http server that lets you change the current PNGTuber model as well as the models expressions and accessories.
Note that it works only with GET requests since it is supposed to be really easily usable in combination with [Streamer.bot](https://streamer.bot/)'s Fetch URL function (which only sends GET Requests).
## Using the Software and creating your Model
When first starting the software you will be greeted by a cat (the default model). Enter the options menu by right clicking on the model and choosing "Options". In the options menu, make sure to set a folder in which you want to save your PNGModels. Close the options menu and open the create model menu by right clicking again and selecting "Create Model". Choose a model name, add your expressions and accessories (change the neutral expression, or any other expression you already added by double-clicking on the expression name in the expressions box), then hit save. Afterwards enter the options again and select your model from the dropdown menu. You might have to tweak the settings for voice threshold and smoothing depending on how much your microphone picks up and how loud your voice is in relation to the background noise. It is currently not recommended to change the server port, as that will lead to the web-UI no longer functioning since the ports are currently hardcoded. If you want to use the model in OBS you can now either add an application capture and key out the small remaining outline, or you can use it as a browser source with the URL `http://127.0.0.1:8000/webui/model/`. Make sure to set the dimensions of your browser source to match the dimensions of your model.
## The PNGTuber model
The PNGTuber model file is a zip file containing the different expressions and accessories (with neutral as the basic expression) as png files. These files need to be named accordingly. Expression files start with `exp_`
followed by the name of the expression for example `neutral` which is in term followed by another underscore and then a numer from 0 to 3:
```
exp_neutral_0.png - not speaking, not blinking
exp_neutral_1.png - speaking, not blinking
exp_neutral_2.png - not speaking, blinking
exp_neutral_3.png - speaking, blinking
```
Accessory files are prefixed with `acc_`:
```
acc_flowers.png
```
---
Please note that this software is just a fun project. It is planned to do some refactoring and cleaning up of the code to improve stability and maintainability. Also some documentation for the http interface is still needed.
