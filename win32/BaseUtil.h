#pragma once

#define CONCAT__(a,b)  a ## b
#define CONCAT(a,b)  CONCAT__(a, b)

#define MAYBE(fn,p)  if (p) { (fn)(p); }
