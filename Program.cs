import RPi.GPIO as GPIO
import tkinter as tk

GPIO.setmode(GPIO.BOARD)
GPIO.setup(17, GPIO.OUT)
GPIO.setup(27, GPIO.OUT)
GPIO.setup(22, GPIO.OUT)

def alloff():
	GPIO.output(17,GPIO.LOW)
	GPIO.output(27,GPIO.LOW)
	GPIO.output(22,GPIO.LOW)


def lighton(pin):
	if GPIO.input(pin) == GPIO.HIGH:
		GPIO.output(pin, GPIO.LOW)
	else:
		GPIO.output(pin,GPIO.HIGH)


window = tk.Tk()
window.title("Control system")

window.geometry("400x300")
window.configure(bg = "black")

chosen = tk.IntVar()


def close():
	GPIO.cleanup()
	window.destroy()


def nolight():
	if chosen.get() == 1:
		light_on(17)
	elif chosen.get() == 2:
		light_on(27)
	elif chosen.get() == 3:
		light_on(22)
		
		
green = tk.Radiobutton(window, text = "GREEN ", variable = chosen, value = 1, command = light_no, bg = "green")
blue = tk.Radiobutton(window, text = "BLUE", variable = chosen, value = 2, command = light_no, bg = "blue")
red = tk.Radiobutton(window, text = "RED", variable = chosen, value = 3, command = light_no, bg = "red")
of = tk.Button(window, text = "OFF ALL", command = all_of, bg = "cyan")

esc = tk.Button(window, text ="EXIT", command = close, bg = "black")

off.pack()
esc.pack()
red.pack()
blue.pack()
green.pack()



window.mainloop()

GPIO.cleanup()
