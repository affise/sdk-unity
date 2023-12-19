platform :ios, '11.0'

target 'UnityFramework' do
   pod 'AffiseInternal', '1.6.19'

   # Affise Modules
   # pod 'AffiseModule/Advertising', '1.6.19'
   # pod 'AffiseModule/Status', '1.6.19'
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
