# SimplePNGTuber
This is yet another PNGTuber software. Its purpose is to be just a small application but with some interesting features that other simple PNGTuber softwares usually dont have.
It has an http server that lets you change the current PNGTuber model as well as the models expressions and accessories.
Note that it works only with GET requests since it is supposed to be really easily usable in combination with [Streamer.bot](https://streamer.bot/)'s Fetch URL function (which only sends GET Requests).
## Using the Software and creating your Model
When first starting the software you will be greeted by a cat (the default model). Enter the options menu by right clicking on the model and choosing "Options". In the options menu, make sure to set a folder in which you want to save your PNGModels. Close the options menu and open the create model menu by right clicking again and selecting "Create Model". Choose a model name, add your expressions and accessories (change the neutral expression, or any other expression you already added by double-clicking on the expression name in the expressions box), then hit save. When adding the accessories you will have a "layer" option. The base model will always be displayed on layer 0. Accessories are put on layer 1 (in front of the model) by default. If you want to layer accessories over each other or display accessories behind the base model you will have to adjust the layer option. Afterwards enter the options again and select your model from the dropdown menu. You might have to tweak the settings for voice threshold and smoothing depending on how much your microphone picks up and how loud your voice is in relation to the background noise. If you want to use the model in OBS you can now either add an application capture and key out the small remaining outline, or you can use it as a browser source with the URL `http://127.0.0.1:8000/webui/model/` (8000 is the default port, if you change the port in the options menu you will have to change it in the url as well). Make sure to set the dimensions of your browser source to match the dimensions of your model. Using the browser source is highly recommended since it has way better performance than the windows form. In fact it is probably a good idea to not enable animating the model in the windows form.
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
## Using the HTTP commands
Once you have setup your model, you are ready to access and control it via HTTP GET Requests.
The base address for this is your local address `127.0.0.1` and the port you have configured in your settings. With the default port of `8000` your base URL would be `http://127.0.0.1:8000`. From there you can do various things:
### Changing the model
At `http://127.0.0.1:8000/setmodel/<modelname>` you can change the current model the software is using. Replace `<modelname>` with the name of your model.
### Changing the expression
At `http://127.0.0.1:8000/setexpression/<expressionname>` you can change the current model the software is using. Replace `<expressionname>` with the name of your models expression.
### Adding or removing accessories
At `http://127.0.0.1:8000/accessory/add/<accessoryname>` you can add accessories to your model. Replace `<accessoryname>` with the name of your models accessory.
At `http://127.0.0.1:8000/accessory/remove/<accessoryname>` you can remove accessories from your model. Replace `<accessoryname>` with the name of your models accessory.
## Using [Streamer.bot](https://streamer.bot/) to control your model
You can use Streamer.bot to execute any of the HTTP commands. To do this, use the "Fetch URL" subaction and set the URL paremeter accordingly. For example if you wanted to add the flowers accessory to your model you would set up the Fetch URL subaction to access `http://127.0.0.1:8000/accessory/add/flowers`.

---
Please note that this software is just a fun project. It is planned to do some refactoring and cleaning up of the code to improve stability and maintainability.
