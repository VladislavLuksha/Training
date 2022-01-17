# 1.	– Xpath , 2. – CSS

# Start page:

a) //input[@id = 'text'] | input#text
b) //div[@class = 'search2__button'] | div.search2__button

# Email page

c) //a[@class='b-toolbar__but' and @aria-label= 'Написать'] | a[aria-label = 'Написать']
d) //a[text()='Выход'] | a[class *= 'exit']
e) //a[text()='Настройка'] | a[class *= 'setup']
f) //div[@class ='b-folders']//span[@class='b-folders__folder__name'] | div[aria-label ='Папки'] .b-folders__folder
g) //span[@class = 'b-folders__folder' or contains(@class, ' b-folders__folder_unread')][position()>2 or position() =1]
  
# New email page:

h) //textarea[@id = 'compose-send'] | #compose-send
i) //input[@id = 'id1168917856530'] | #id1168917856530
j) //input[@name = 'search'] | input[name = 'search']
k) //button[@name = 'nosend'] | button[name = 'nosend']
l) //input[contains(@class, 'b-form-button')] | .b-buttons .b-form-button
m) //input[@class = 'b-compose__file']/..//input[contains(@class, 'b-form-button')] | .b-compose__file ~input
n) //button[@name='nosend']//ancestor::div[@class='b-buttons']//input[contains(@class, 'b-form-button')]
o) //input[contains(@class, 'b-compose__cancel')]/preceding-sibling::input[contains(@class, 'b-form-button')]
p) //div[@class='b-buttons']/input[position()>2 or position()< 2] | .b-buttons input:not(.b-compose__send)

# Sent page:

q) .b-messages__message:nth-child(n+4)
r) //div[@class = 'b-messages__message' or contains(@class,'b-messages__message_last')][position()>=2]
