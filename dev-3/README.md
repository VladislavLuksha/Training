# 1.	– Xpath , 2. – CSS

# Start page:
a)	1. //input[@id = 'text']  
2. input#text
b)	1. //div[@class = 'search2__button']  
2. div.search2__button
# Email page
c)	1. //a[@class='b-toolbar__but' and @aria-label= 'Написать']
2. a[aria-label = 'Написать']
d)	1. //a[text()='Выход']
2. a[class *= 'exit']
e)	1. //a[text()='Настройка']
2. a[class *= 'setup']
f)	1. //div[@class ='b-folders']//span[@class='b-folders__folder__name']
2. div[aria-label ='Папки'] .b-folders__folder
g)	1. //span[@class = 'b-folders__folder' or contains(@class, ' b-folders__folder_unread')][position()>2 or position() =1]
2.----------------------------
# New email page:
h)	1. //textarea[@id = 'compose-send']
2. #compose-send
i)	1. //input[@id = 'id1168917856530']
2. #id1168917856530
j)	1. //input[@name = 'search']
2. input[name = 'search']
k)	1. //button[@name = 'nosend']
2. button[name = 'nosend']
l)	1. //input[contains(@class, 'b-form-button')]
2. .b-buttons .b-form-button
m)	1. //input[@class = 'b-compose__file']/..//input[contains(@class, 'b-form-button')]
2. .b-compose__file ~input
n)	1. //button[@name='nosend']//ancestor::div[@class='b-buttons']//input[contains(@class, 'b-form-button')]
2.  ------
o)	1. //input[contains(@class, 'b-compose__cancel')]/preceding-sibling::input[contains(@class, 'b-form-button')]
p)	1. //div[@class='b-buttons']/input[position()>2 or position()< 2]
2.	.b-buttons input:not(.b-compose__send)
# Sent page:
q)	2. .b-messages__message:nth-child(n+4)
r)	1. //div[@class = 'b-messages__message' or contains(@class,'b-messages__message_last')][position()>=2]


