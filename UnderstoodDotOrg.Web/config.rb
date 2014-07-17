# Require any additional compass plugins here.
require "breakpoint"

# asset dirs
css_dir = "Presentation/includes/css"
sass_dir = "Presentation/includes/css.source"
images_dir = "Presentation/includes/images"
javascripts_dir = "Presentation/includes/js"

# Set this to the root of your project when deployed:
http_path = "/"

# You can select your preferred output style here (can be overridden via the command line):
output_style = :expanded

# To enable relative paths to assets via compass helper functions. Uncomment:
relative_assets = true

# To disable debugging comments that display the original location of your selectors. Uncomment:
line_comments = true


# override default compass cache buster (appears to be file mtime- or 
# ctime-based) with more deterministic hashing via SHA2. shorten the 
# hash to 8 chars to reduce ugliness.
require 'digest'

asset_cache_buster do |path, real_path|
  if File.exists?(real_path)
	cachebuster = Digest::SHA2.file(real_path).hexdigest[0..7]

    {:path => path, :query => cachebuster}
  end
end



# # Make a copy of sprites with a name that has no uniqueness of the hash.
# on_sprite_saved do |filename|
# 	if File.exists?(filename)
# 		FileUtils.cp filename, filename.gsub(%r{-s[a-z0-9]{10}\.png$}, '.png')
# 		# Note: Compass outputs both with and without random hash images.
# 		# To not keep the one with hash, add: (Thanks to RaphaelDDL for this)
# 		FileUtils.rm_rf(filename)
# 	end
# end

# # Replace in stylesheets generated references to sprites
# # by their counterparts without the hash uniqueness.
# on_stylesheet_saved do |filename|
# 	if File.exists?(filename)
# 		css = File.read filename
# 		File.open(filename, 'w+') do |f|
# 			f << css.gsub(%r{(?<start>-s)(?<hash>[a-z0-9]{10})(?<file>\.png)}, '.png?v=\k<hash>')
# 		end
# 	end
# end
