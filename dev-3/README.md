# Locate css and xpath selectors for following elements in yandex.by 

# Start page:

a) Search input

b) Find button

# Email page (switch from full to light version, see screenshot a):

c) Write email button

d) Logout link

e) Settings link

f) 1 locator for all 5 elements: Inbox, Sent, Deleted, Spam and Draft links

g) 1 locator for all 4 elements: Inbox, Deleted, Spam and Draft links

# New email page:

h) To input

i) Topic input

j) Find button

k) Add multiple attachments button

l) 1 locator for all 3 elements: Send, Save and Cancel inputs

m) Update locator (just add any code after it, but initial part must be presented as beginning of locator) “.b-compose__file” | ”//input[@class='b-compose__file']” to grab all 3 elements: Send, Save and Cancel inputs

n) Update locator (just add any code after it, but initial part must be presented as beginning of locator) “button[name='nosend']” | “//button[@name='nosend']” to grab all 3 elements: Send, Save and Cancel inputs

o) Xpath only. Update locator (just add any code after it, but initial part must be presented as beginning of locator) “//input[contains(@class, 'b-compose__cancel')]” to grab all 2 elements: Send and Save inputs

p) Update locator (just add any code after it, but initial part must be presented as beginning of locator) “.b-buttons>input” | “//div[@class='b-buttons']/input” to grab all 3 elements: Choose Files, Save and Cancel inputs

# Sent page:

q) Css only. Locator to get even links to topics starting from 4th email

r) Xpath only. Locator to get all links to topics starting from 2nd email
