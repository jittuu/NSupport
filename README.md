# NSupport

A .Net port of ActiveSupport library of Ruby on Rails. The goal is to extend Base Class Library for Common Usage with human readable syntax.

# Installation

You can use NSupport by using either _Nuget_ **OR** _DLL download_.

### Nuget
> Install-Package NSupport

More information about nuget package at http://www.nuget.org/List/Packages/NSupport.

### DLL download
You can download the [latest released DLL](https://github.com/downloads/jittuu/NSupport/NSupport%20v1.3.1.zip) and add reference to your project.

# Usage

**NSupport** extends the BCL by adding extension methods, so you need to add the using reference to your code.

```c#
    using NSupport;
```

NSupport extends [DateTime](http://msdn.microsoft.com/en-us/library/system.datetime.aspx) and [DateTimeOffset](http://msdn.microsoft.com/en-us/library/system.datetimeoffset.aspx) to allow you to write as below and more:

```c#
	var june18 = new DateTime(2011,6,18);
		
	june18.Tomorrow(); // 2011/06/19
	
	june18.Yesterday(); // 2011/06/17
	
	june18.Nextyear(); // 2012/06/18
	
	june18.EndOfDay(); // 2011/06/18 23:59:59
	
	june18.BeginnerOfMonth(); // 2011/06/01
	
	june18.EndOfMonth(); // 2011/06/30 23:59:59
	
	june18.BeginningOfWeek(); // 2011/06/12
	
	june18.NextWeek(DayOfWeek.Friday); // 2011/06/24
	
	june18.BeginningOfQuarter(); // 2011/04/01
	
	june18.IsToday(); // true if today is june 18 2011 regardless of time
	
	june18.Change(years: 2010); // 2010/06/18
```

it also extends [Integer](http://msdn.microsoft.com/en-us/library/system.int32.aspx) to enable to write as:

```c#
	2.IsEven(); // true
	1.IsEven(); // false
	0.IsOdd(); // false
	
	15.IsMultipleOf(3); // true
	
	1.Byte(); // 1
	1.Kilobyte(); // 1024
	2.Megabytes(); // 2*1024*1024
	
	// looping 10 times
	10.Times(() => {
		// do something which will be executed for 10 times.
	});
```

when [Integer](http://msdn.microsoft.com/en-us/library/system.int32.aspx) loves [TimeSpan](http://msdn.microsoft.com/en-us/library/system.timespan.aspx)

```c#
	1.Hour(); // Timespan of 1 hour
	30.Minutes().Ago(); // 30 minutes ago 
	(2.Hours() + 20.Minutes()).FromNow();  // 2 hours and 20 minutes from now
	
	10.Hours().Since(new DateTime(2011,6,18)); // 2011/06/18 10:00:00
```

converting **string** to _numbers_. 

```c#
	"10".ToInt32(); // convert to int 10
	"10,000".ToDecimal(); // convert to decimal 10000 
	
	"5".AsInt32(); // convert to int? 5
	"notValidNumber".AsInt32(); // return null
	
	var i = "notValidNumber".AsInt32() ?? -1; // i will have -1 (no more int.TryParse :) )	
```

formatting **string**.

```c#
	"{0} is {1} years old".FormatWith("Michael", 23); // Michael is 23 years old.	
```

securing **text**

```c#
  var password = "awesomeSecretPassword";
  var salt = "123jfe3EJV24098EC"; // or Guid.NewGuid().ToString("N");
  
  // hash password, so that no one can retrieve password
  var digestPassword = password.ToHashString(salt);
  
  var importantText = "this is super important text, so it need to be encrypt.";
  var secretKey = "thisIsSecretKey";
  
  // encrypt text so that other cannot read but I have key, so I can decrypt back to original one
  var encryptedText = importantText.Encrypt(secretKey);
  
  // decrypt to original
	var decryptedText = encryptedText.Decrypt(secertKey); // decryptedText == importantText
```

# CONTRIBUTE

If you find any bug, please file a bug in [Github Issue](https://github.com/jittuu/NSupport/issues).

If you have any idea for extending BCL or any doubt in using NSupport, please post message in [discussion board](http://groups.google.com/group/nsupport-lib).

If you want to hack NSupport, start by forking my repo on GitHub:

https://github.com/soemoe/nsupport